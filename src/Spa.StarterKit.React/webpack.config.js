var isDevBuild = process.argv.indexOf('--env.prod') < 0;
var path = require('path');
var webpack = require('webpack');
var ExtractTextPlugin = require('extract-text-webpack-plugin');
var merge = require('webpack-merge');
var copyWebpackPlugin = require('copy-webpack-plugin');

// Configuration in common to both client-side and server-side bundles
var sharedConfig = () => ({
    resolve: { extensions: ['', '.js', '.jsx'] },
    output: {
        filename: '[name].js',
        publicPath: '/dist/' // Webpack dev middleware, if enabled, handles requests for this URL prefix
    },
    module: {
        loaders: [
            { test: /\.jsx?$/, include: /Client/, loader: 'babel-loader' }
        ]
    }
});

// Configuration for client-side bundle suitable for running in browsers
var clientBundleOutputDir = './wwwroot/dist';
var clientBundleConfig = merge(sharedConfig(), {
    entry: {
        'main-client': [
            './Client/Index.jsx'
        ]
    },
    module: {
        loaders: [
            { test: /\.css$/, loader: ExtractTextPlugin.extract(['css-loader']) },
            { test: /\.(png|jpg|jpeg|gif|svg)$/, loader: 'url-loader', query: { limit: 25000 } },
            {
                test: /\.scss$/,
                loaders: ['style-loader', 'css-loader', 'sass-loader']
            }
        ]
    },
    sassLoader: {
        includePaths: [path.resolve(__dirname, './sass')]
    },
    output: { path: path.join(__dirname, clientBundleOutputDir) },
    plugins: [
        new ExtractTextPlugin('site.css'),
        new webpack.DllReferencePlugin({
            context: __dirname,
            manifest: require('./wwwroot/dist/vendor-manifest.json')
        }),
        new copyWebpackPlugin([
            { from: 'Client/images', to: 'images' }
        ])
    ].concat(isDevBuild ? [
        // Plugins that apply in development builds only
        new webpack.SourceMapDevToolPlugin({
            filename: '[file].map', // Remove this line if you prefer inline source maps
            moduleFilenameTemplate: path.relative(clientBundleOutputDir, '[resourcePath]') // Point sourcemap entries to the original file locations on disk
        })
    ] : [
        // Plugins that apply in production builds only
        new webpack.optimize.OccurenceOrderPlugin(),
        new webpack.optimize.UglifyJsPlugin({ compress: { warnings: false } })
    ])
});

// Configuration for server-side (prerendering) bundle suitable for running in Node
var serverBundleConfig = merge(sharedConfig(), {
    resolve: { packageMains: ['main'] },
    entry: { 'main-server': './Client/index.jsx' },
    plugins: [
        new webpack.DllReferencePlugin({
            context: __dirname,
            manifest: require('./Client/dist/vendor-manifest.json'),
            sourceType: 'commonjs2',
            name: './vendor'
        })
    ],
    output: {
        libraryTarget: 'commonjs',
        path: path.join(__dirname, './Client/dist')
    },
    target: 'node',
    devtool: 'inline-source-map'
});

module.exports = [clientBundleConfig, serverBundleConfig];

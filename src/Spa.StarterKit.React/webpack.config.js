//let isDevBuild = process.argv.indexOf('--env.prod') < 0;
//const extractTextPlugin = require('extract-text-webpack-plugin');
//const path = require('path');
//const merge = require('webpack-merge');
//const autoprefixer = require('autoprefixer');
//const clientBundleOutputDir = './wwwroot/dist';
//const webpack = require('webpack');
//const copyWebpackPlugin = require('copy-webpack-plugin');

//const sharedConfig = () => ({
//    resolve: { extensions: ['', '.js', '.jsx', '.scss'] },
//    moduleDirectories: [
//        'node_modules'
//    ],
//    output: {
//        filename: '[name].js',
//        publicPath: '/dist/'
//    },
//    module: {
//        loaders: [
//        {
//            test: /\.jsx$/,
//            include: /Client/,
//            loader: 'babel-loader'//,
//            //exclude: /(node_modules|bower_components)/

//        }
//        ]
//    }
//});

//const clientBundleConfig = merge(sharedConfig(),
//{
//    //context: path.join(__dirname, 'Client'),
//    entry: {
//                'main-client': [
//                    './Client/Index.jsx'
//                ]
//            },
//    output: {
//        path: path.join(__dirname, 'Client', 'Dist'),
//        filename: '[name].js'
//    },
//    module: {
//        loaders: [
//            { test: /\.(png|jpg|jpeg|gif|svg)$/, loader: 'url-loader', query: { limit: 25000 } },
//            { test: /\.(scss|css)$/, loader: 'style-loader!css-loader?sourceMap&modules&importLoaders=1&localIdentName=[name]-[local]___[hash:base64:5]!sass-loader?sourceMap' }
//        ]
//    },
//    postcss: function () {
//        return [autoprefixer({
//            browsers: ['last 3 versions']
//        })];
//    },
//    plugins: [
//        new extractTextPlugin('site.css'),
//        new webpack.DllReferencePlugin({
//            context: __dirname,
//            manifest: require('./wwwroot/dist/vendor-manifest.json')
//        }),
//        new copyWebpackPlugin([
//            { from: 'Client/images', to: 'images' }
//        ])
//    ].concat(isDevBuild ? [
//        // Plugins that apply in development builds only
//        new webpack.SourceMapDevToolPlugin({
//            filename: '[file].map', // Remove this line if you prefer inline source maps
//            moduleFilenameTemplate: path.relative(clientBundleOutputDir, '[resourcePath]') // Point sourcemap entries to the original file locations on disk
//        })
//    ] : [
//        // Plugins that apply in production builds only
//        new webpack.optimize.OccurenceOrderPlugin(),
//        new webpack.optimize.UglifyJsPlugin({ compress: { warnings: false } })
//    ])
//});

////const serverBundleConfig = merge(sharedConfig(), {
////    resolve: {
////         packageMains: ['main']
////    },
////    module: {
////        loaders: [
////          {
////              test: /\.jsx$/,
////              include: /Client/,
////              loader: 'babel-loader',
////              exclude: /(node_modules|bower_components)/

////          },
////        {
////            test: /\.scss$/,
////            loaders: ['style', 'css', 'postcss', 'sass']
////        }]
////    },
////    entry: {
////         'main-server': './Client/index.jsx'
////    },
////    plugins: [
////        new webpack.DllReferencePlugin({
////            context: __dirname,
////            manifest: require('./Client/dist/vendor-manifest.json'),
////            sourceType: 'commonjs2',
////            name: './vendor'
////        })
////    ],
////    output: {
////        libraryTarget: 'commonjs',
////        path: path.join(__dirname, './Client/dist')
////    },
////    target: 'node',
////    devtool: 'inline-source-map'
////});

//module.exports = [clientBundleConfig];//, serverBundleConfig];

////module.exports = {
////    context: path.join(__dirname, 'Client'),
////    entry: './Index.jsx',
////    output: {
////        path: path.join(__dirname, 'Client', 'Dist'),
////        filename: '[name].bundle.js'
////    }
////};



var isDevBuild = process.argv.indexOf('--env.prod') < 0;
var path = require('path');
var webpack = require('webpack');
var ExtractTextPlugin = require('extract-text-webpack-plugin');
var merge = require('webpack-merge');
var copyWebpackPlugin = require('copy-webpack-plugin');
var autoprefixer = require('autoprefixer');

// Configuration in common to both client-side and server-side bundles
var sharedConfig = () => ({
    resolve: { extensions: ['', '.js', '.jsx'] },
    output: {
        filename: '[name].js',
        publicPath: '/dist/' // Webpack dev middleware, if enabled, handles requests for this URL prefix
    },
    module: {
        loaders: [
            { test: /\.jsx?$/, include: /Client/, loader: 'babel-loader', exclude: /(node_modules|bower_components)/ }
        ]
    }
});


console.log(path.resolve(__dirname, './node_modules/react-toolbox/'));

console.log(path.resolve(__dirname, './theme.scss'));

console.log(path.resolve(__dirname, './Client/sass/'));

// Configuration for client-side bundle suitable for running in browsers
var clientBundleOutputDir = './wwwroot/dist';
var clientBundleConfig = merge(sharedConfig(),
{
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
                exclude: [
                    path.resolve(__dirname, './Client/sass/')
                ],
                loaders: [
                    'style',
                    'css?sourceMap&modules&importLoaders=1&localIdentName=[name]__[local]___[hash:base64:5]!postcss!sass!toolbox'
                ]
            },
            {
                test: /\.scss$/,
                include: [
                    path.resolve(__dirname, './Client/sass/')
                ],
                loaders: ['style-loader', 'css-loader', 'postcss', 'sass-loader']
            }
            
        ]
    },
    postcss: function() {
        return [autoprefixer];
    },
    //},
    //sassLoader: {
    //    includePaths: [path.resolve(__dirname, './Client/sass')]
    //},
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

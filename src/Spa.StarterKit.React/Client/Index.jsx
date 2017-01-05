import React from 'react';
import ReactDom from 'react-dom';
import routes from './config/routes';

//require('./sass/global.scss');
//import './sass/global.scss'; //global style import

ReactDom.render(
    routes,
    document.getElementById('app')
);
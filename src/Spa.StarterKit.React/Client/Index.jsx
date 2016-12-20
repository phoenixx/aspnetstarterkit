import React from 'react';
import ReactDom from 'react-dom';
import routes from './config/routes';
import './sass/global.scss'; //global style import

ReactDom.render(
    routes,
    document.getElementById('app')
);
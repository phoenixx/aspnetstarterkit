import React from 'react';
import ReactDom from 'react-dom';
import Routes from './config/routes';

//require('./sass/global.scss');
//import './sass/global.scss'; //global style import

ReactDom.render(
    <Routes/>,
    document.getElementById('app')
);
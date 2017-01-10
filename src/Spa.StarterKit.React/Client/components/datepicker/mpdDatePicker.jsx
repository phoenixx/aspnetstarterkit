import React, { Component } from 'react';
import DatePicker from 'react-toolbox/lib/date_picker';
import theme from './theme.scss';

const MpdDatePicker = (props) => (
    <DatePicker {...props} theme={theme}/>
);

export default MpdDatePicker;
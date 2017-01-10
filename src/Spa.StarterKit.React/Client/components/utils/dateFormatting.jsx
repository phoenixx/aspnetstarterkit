import React, { Component } from 'react';
import { FormattedDate } from 'react-intl';

class TextDate extends Component {
    constructor(props) {
        super(props);
    }
    render() {
        return(
            <FormattedDate {...this.props}
                year="numeric"
                month="short"
                day="numeric"
                weekday="short"/>
        );
    }
}

class LongDate extends Component {
    constructor(props) {
        super(props);
    }
    render() {
        return(
            <FormattedDate {...this.props}
                year="numeric"
                month="long"
                day="numeric"
                weekday="short"/>
        );
    }
}

class ShortDate extends Component {
    constructor(props) {
        super(props);
    }
    render() {
        return(
            <FormattedDate {...this.props}
                year="numeric"
                month="numeric"
                day="numeric"
                />
        );
    }
}

class Date extends Component {
    constructor(props) {
        super(props);
    }
    render() {
        return(
            <FormattedDate {...this.props}/>
        );
    }
}

export {
    TextDate, LongDate, ShortDate, Date
};
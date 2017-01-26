import React, { Component } from 'react';
import { FormattedDate, FormattedTime } from 'react-intl';

class TextDate extends Component {
    constructor(props) {
        super(props);
    }
    render() {
        if (this.props.value) {
            return(
                <FormattedDate {...this.props}
                    year="numeric"
                    month="short"
                    day="numeric"
                    weekday="short"/>
            );
        } else {
            return null;
        }
    }
}

class LongDate extends Component {
    constructor(props) {
        super(props);
    }
    render() {
        if (this.props.value) {
            return(
                <FormattedDate {...this.props}
                    year="numeric"
                    month="long"
                    day="numeric"
                    weekday="short"/>
            );
        } else {
            return null;
        }
    }
}

class ShortDate extends Component {
    constructor(props) {
        super(props);
    }
    render() {
        if (this.props.value) {
            return(
                <FormattedDate {...this.props}
                    year="numeric"
                    month="numeric"
                    day="numeric"
                    />
            );
        } else {
            return null;
        }
    }
}

class Date extends Component {
    constructor(props) {
        super(props);
    }
    render() {
        if (this.props.value) {
            return(
                <FormattedDate {...this.props}/>
            );
        } else {
            return null;
        }
    }
}

class DateTime extends Component {
    constructor(props) {
        super(props);
    }
    render() {
        if (this.props.value) {
            return(
                   <span>
                    <FormattedDate {...this.props} year="numeric" month="numeric" day="numeric"/>
                            &nbsp;
                    <FormattedTime {...this.props}/>
                </span>
            );
        } else {
            return null;
        }
    }
}

class DateTimeSeconds extends Component {
    constructor(props) {
        super(props);
    }
    render() {
        if (this.props.value) {
            return(
                <span>
                    <FormattedDate {...this.props} year="numeric" month="numeric" day="numeric"/>
                    &nbsp;
                    <FormattedTime {...this.props} hour="numeric" minute="numeric" second="numeric"/>
                </span>
            );
        } else {
            return null;
        }
    }
}

export {
    TextDate, LongDate, ShortDate, Date, DateTime, DateTimeSeconds
};
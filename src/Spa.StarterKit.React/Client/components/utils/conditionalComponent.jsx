import React, { Component } from 'react';

class ConditionalComponent extends Component {
    constructor(props) {
        super(props);
    }
    render() {
        const doRender = this.props.condition();
        if (doRender === true) {
            return(<span>{this.props.children}</span>);
        } else {
            return null;
        }
    }
}

export default ConditionalComponent;
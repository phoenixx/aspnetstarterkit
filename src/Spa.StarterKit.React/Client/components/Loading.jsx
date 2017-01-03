import React from 'react';
import '../sass/loading.scss';

class Loading extends React.Component {
    render() {
        return(
            <div className="animation-loading">
                <ul>
                    <li></li>
                    <li></li>
                    <li></li>
                    <li></li>
                    <li></li>
                    <li></li>
                    <li></li>
                    <li></li> 
                </ul>
            </div>
        );
    }
}

export default Loading;
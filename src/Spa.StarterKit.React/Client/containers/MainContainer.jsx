import React from 'react';
import { Grid, Layout } from 'react-mdl';

function MainContainer(props) {
    return(
        <div>
            {props.children}
        </div>
    );
};

export default MainContainer;
import React from 'react';

function PageError(props){
    return <div className="container">{props.error.message}</div>
}

export default PageError;
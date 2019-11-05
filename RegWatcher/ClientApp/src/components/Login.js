import React from 'react';
import { connect } from 'react-redux';

const Login = props => (
    <div>
        <h1>Hello, world!</h1>
        <h2>Здесь логин</h2>
    </div>
);

export default connect()(Login);


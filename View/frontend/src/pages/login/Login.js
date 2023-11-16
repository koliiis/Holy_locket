import React, { useState } from 'react';
import './Login.css';
import axios from 'axios';

function Login() {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');

    const handleSubmit = (e) => {
        e.preventDefault();

        const loginData = {
            email,
            password,
        };

        axios
            .post('https://localhost:7172/api/Login', {
                email: loginData.email,
                password: loginData.password,
            })
            .then((response) => {
                console.log('Login success');
            })
            .catch((error) => {
                console.error('Login failed:', error);
            });
    };

    return (
        <div className="login-container">
            <form onSubmit={handleSubmit}>
                <div className="login-form">
                    <h2 className="header">Увійти</h2>
                    <div className="input">
                        <input
                            type="email"
                            name="useremail"
                            placeholder="Email"
                            value={email}
                            onChange={(e) => setEmail(e.target.value)}
                        /><br />

                        <input
                            type="password"
                            name="password"
                            placeholder="Пароль"
                            value={password}
                            onChange={(e) => setPassword(e.target.value)}
                        /><br />
                    </div>
                    <div className="button">
                        <button className="button_left" type="submit">
                            Увійти
                        </button>
                    </div>
                </div>
            </form>
        </div>
    );
}

export default Login;

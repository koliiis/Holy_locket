import React, { useState } from 'react';
import './Login.scss';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';

function Login() {
    const [phone, setPhone] = useState('');
    const [password, setPassword] = useState('');
    const navigate = useNavigate();

    const handleSubmit = async (e) => {
        e.preventDefault();

        try {
            const response = await axios.post('https://localhost:7172/api/Patient/login', {
                phone: phone,
                password: password,
            });

            const jwtToken = response.data.token;

            const idUser = response.data.id;

            console.log(jwtToken, idUser);

            sessionStorage.setItem('jwtToken', jwtToken);
            sessionStorage.setItem('idUser', idUser);

            navigate('/landing');

            console.log('Успешный вход, JWT токен:', jwtToken);
        } catch (error) {
            console.error('Ошибка при входе:', error);
        }
    };

    return (
        <div className="container-fluid mx-auto master">
            <form action="#" method="POST" onSubmit={handleSubmit}>
                <div className="master_login">
                    <h2 className="header_log">Увійти</h2>
                    <div className="input">

                        <div className="input-box-log">
                            <input
                                className="ent-log"
                                required="required"
                                type="tel"
                                name="usernumber"
                                value={phone}
                                onChange={(e) => setPhone(e.target.value)}
                            />
                            <span>Номер телефону</span>
                            <i></i>
                        </div>

                        <div className="input-box-log">
                            <input
                                className="ent-log"
                                required="required"
                                type="password"
                                name="user_password"
                                value={password}
                                onChange={(e) => setPassword(e.target.value)}
                            />
                            <span>Ваш пароль</span>
                            <i></i>
                        </div>

                    </div>
                    <div className="buttonn">
                        <button className='button_log' type="submit">Вхід</button>
                    </div>
                </div>
            </form>
        </div>
    );
}

export default Login;

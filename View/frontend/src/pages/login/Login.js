import React, { useState } from 'react';
import './Login.css';
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

            // После успешного входа получаем токен
            const jwtToken = response.data.token;

            // Сохраняем токен в сессию
            sessionStorage.setItem('jwtToken', jwtToken);

            // Далее можно выполнить перенаправление на другую страницу
            // Например, на страницу профиля
            navigate('/profile');

            console.log('Успешный вход, JWT токен:', jwtToken);
        } catch (error) {
            console.error('Ошибка при входе:', error);
        }
    };

    return (
        <div className="master">
            <form action="#" method="POST" onSubmit={handleSubmit}>
                <div className="master_login">
                    <h2 className="header">Увійти</h2>
                    <div className="input">
                        <input
                            placeholder="Номер телефону"
                            type="tel"
                            name="usernumber"
                            value={phone}
                            onChange={(e) => setPhone(e.target.value)}
                        /><br />

                        <input
                            placeholder="Ваш пароль"
                            type="password"
                            name="user_password"
                            value={password}
                            onChange={(e) => setPassword(e.target.value)}
                        /><br />
                    </div>
                    <div className="button">
                        <button className='button_left' type="submit">Увійти</button>
                    </div>
                </div>
            </form>
        </div>
    );
}

export default Login;

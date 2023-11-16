import React, { useState } from 'react';
import './Login.css';
import axios from "axios";

function Registration() {
    const [phone, setPhone] = useState('');
    const [password, setPassword] = useState('');
    const handleSubmit = (e) => {
        e.preventDefault();

        const data = {
            phone,
            password
        };

        axios.post('https://localhost:7172/api/Patient', {
            firstName: data.name,
            secondName: data.surname,
            phone: data.phoneNumber,
            email: data.email,
        })

            .then((response) => {
                console.log("Peremoga");
            })
            .catch((error) => {
                console.error('Ошибка при отправке данных:', error);
            });
    }


    return (
        <div className="master">
            <form action="#" method="POST"  onSubmit={handleSubmit}>
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

export default Registration;

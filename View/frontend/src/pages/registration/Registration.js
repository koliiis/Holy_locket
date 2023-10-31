import React from 'react';
import './Registration.css';

function Registration() {
    return (
        <div className="master">
            <form action="#" method="POST">
                <div className="master_2">
                    <h2 className="header">Реєстрація</h2>
                    <div className="input">
                        <input placeholder="Ім'я" type="text" name="username" /><br />
                        <input placeholder="Прізвище" type="text" name="username" /><br />
                        <input placeholder="Номер телефону" type="tel" name="usernumber" /><br />
                        <input placeholder="Вам email" type="email" name="useremail"/><br />
                    </div>
                    <div className="button">
                        <button className='button_left' type="submit">Зареєструватися</button>
                        <button className='button_right' type="reset">Уже маю аккаунт</button>
                    </div>
                </div>
            </form>
        </div>
    );
}

export default Registration;

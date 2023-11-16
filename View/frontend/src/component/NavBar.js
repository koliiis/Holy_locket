import React from 'react';
import { useNavigate } from 'react-router-dom';
import './Navbar.css';

import img1 from "./img1.png";

const NavBar = () => {
    const navigate = useNavigate();

    return (
        <div className="main">
            <div className="logo">
                <strong className="loggo">HOLY Locket</strong>
            </div>

            <nav>
                <ul className="choose">
                    <li>
                        <button className="btn" onClick={() => navigate("/landing")}>ГОЛОВНА</button>
                    </li>

                    <li>
                        <button className="btn" onClick={() => navigate("/doctors")}>Лікарі</button>
                    </li>

                    <li>
                        <button className="btn" onClick={() => navigate("/patientsappointments")}>Мої записи</button>
                    </li>
                    <button className="btn1" onClick={() => navigate("/registration")}>Зареєструватися</button>
                <button className="btn1" onClick={() => navigate("/login")}>Ввійти</button>
                <img className="btn2" src={img1} onClick={() => navigate("/patientprofile")}></img>
                </ul>

            </nav>
        </div>
    );
};

export default NavBar;

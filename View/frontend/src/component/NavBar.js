import React from 'react';
import { useNavigate } from 'react-router-dom';
import './Navbar.css';

const NavBar = () => {
    const navigate = useNavigate();

    return (
        <div className="main">
            <div className="logo">
                <strong>HOLY Locket</strong>
            </div>

            <nav>
                <ul className="choose">
                    <li>
                        <button className="btn" onClick={() => navigate("/registration")}>ГОЛОВНА</button>
                    </li>

                    <li>
                        <button className="btn" onClick={() => navigate("/doctors")}>Лікарі</button>
                    </li>

                    <li>
                        <button className="btn" onClick={() => navigate("/appointment")}>Мої записи</button>
                    </li>
                </ul>
            </nav>
        </div>
    );
};

export default NavBar;

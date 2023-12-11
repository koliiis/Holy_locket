import React from 'react';
import './landing.scss';

function Landing() {
    return (
        <div className="container-fluid bodys">
            <div id="carouselExampleFade" className="row carousel slide carousel-fade justify-content-center align-items-center allofthat" data-bs-ride="carousel">
                <div className="col-xl-6 col-sm-8 www">
                    <div className="carousel-innerс">
                        <div className="carousel-item active">
                            <img src="https://thumbs.dreamstime.com/b/%D0%BD%D1%8E%D0%BD%D0%B8-%D0%B4%D0%BE%D0%BA%D1%82%D0%BE%D1%80%D0%BE%D0%B2-8151070.jpg" className="d-block w-100" alt="..." />
                        </div>
                        <div className="carousel-item">
                            <img src="data:image/jpeg;base64,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" className="d-block w-100" alt="..." />
                        </div>
                        <div className="carousel-item">
                            <img src="https://media.myshows.me/shows/760/1/89/18959b3b56cc6c12ea63e7bb039690f0.jpg" className="d-block w-100" alt="..." />
                        </div>
                    </div>
                    <button className="carousel-control-prev btn-prx" type="button" data-bs-target="#carouselExampleFade" data-bs-slide="prev">
                        <span className="carousel-control-prev-icon" aria-hidden="true"></span>
                        <span className="visually-hidden">Previous</span>
                    </button>
                    <button className="carousel-control-next btn-next" type="button" data-bs-target="#carouselExampleFade" data-bs-slide="next">
                        <span className="carousel-control-next-icon" aria-hidden="true"></span>
                        <span className="visually-hidden">Next</span>
                    </button>
                </div>
                <div className="col-xl-4 col-sm-8 col-12 main-text">
                    <h2 className="headerr">НАША ЛІКАРНЯ</h2>
                    <p className="textt">Елітна приватна лікарня в Києві - сучасний заклад у престижному районі з високотехнологічним обладнанням. Індивідуальні палати, комфорт та конфіденційність. Кваліфікований медперсонал, широкий спектр послуг, включаючи косметологію та антивікову медицину. Підвищений рівень обслуговування та уваги до пацієнтів </p>
                </div>
            </div>
        </div>
    );
}

export default Landing;

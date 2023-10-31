import React, { useState, useEffect } from 'react';
import './landing.css'; // Импортируйте ваш стилевой файл

function Landing() {
    const [currentSlide, setCurrentSlide] = useState(1);

    // Функция для переключения слайдов
    function plusSlides(n) {
        showSlides(currentSlide + n);
    }

    // Функция для отображения слайдов
    function showSlides(n) {
        const slides = document.querySelectorAll('.mySlides');
        let dots = document.querySelectorAll('.dot');

        if (n > slides.length) {
            n = 1;
        }
        if (n < 1) {
            n = slides.length;
        }
        slides.forEach((slide) => {
            slide.style.display = 'none';
        });
        dots.forEach((dot) => {
            dot.className = dot.className.replace(' active', '');
        });
        slides[n - 1].style.display = 'block';
        dots[n - 1].className += ' active';
        setCurrentSlide(n);
    }

    // Эффект для автоматической смены слайдов
    useEffect(() => {
        showSlides(currentSlide); // При загрузке страницы отобразить текущий слайд
        const timer = setInterval(() => {
            plusSlides(1);
        }, 4000); // Измените интервал переключения, если необходимо

        return () => {
            clearInterval(timer);
        };
    }, []);

    return (
        <div className="bodys">
        <div className="slideshow-container">
            <div className={`mySlides fade ${currentSlide === 1 ? 'visible' : ''}`}>
                <div className="numbertext">1 / 3</div>
                <img src="https://zn.ua/img/article/1943/80_main.jpg" style={{ width: '100%' }} alt="Slide 1" />
            </div>

            <div className={`mySlides fade ${currentSlide === 2 ? 'visible' : ''}`}>
                <div className="numbertext">2 / 3</div>
                <img src="https://blog.amediateka.ru/wp-content/uploads/2019/01/skoraya-pomoshh.jpg" style={{ width: '100%' }} alt="Slide 2" />
            </div>

            <div className={`mySlides fade ${currentSlide === 3 ? 'visible' : ''}`}>
                <div className="numbertext">3 / 3</div>
                <img src="https://podborkiserialov.ru/wp-content/uploads/2021/08/er-1024x601.jpg" style={{ width: '100%' }} alt="Slide 3" />
            </div>

            <a className="prev" onClick={() => plusSlides(-1)}>
                &#10094;
            </a>
            <a className="next" onClick={() => plusSlides(1)}>
                &#10095;
            </a>

            <div style={{ textAlign: 'center' }}>
                <span className={`dot ${currentSlide === 1 ? 'active' : ''}`} onClick={() => showSlides(1)}></span>
                <span className={`dot ${currentSlide === 2 ? 'active' : ''}`} onClick={() => showSlides(2)}></span>
                <span className={`dot ${currentSlide === 3 ? 'active' : ''}`} onClick={() => showSlides(3)}></span>
            </div>
            <h2 className="headerr">НАША ЛІКАРНЯ</h2>
            <p className="main-text">Avenir Light is a clean and stylish font favored by designers. It's easy on the eyes and a great go-to font for titles, paragraphs & more. SKkxsmxkmxkmskxlxm,m m m mm mmkcmcdmdxx,xllllllll m kclmldcmld ldc,c;/.</p>
        </div>
        </div>
    );
}

export default Landing;

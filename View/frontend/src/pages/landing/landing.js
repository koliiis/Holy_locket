import React from 'react';
import './landing.scss';

function Landing() {
    return (
        <div className="container-fluid row bodys">
            <div className="col-8 col-12-lg blurd">
                <span className="subscript_frs">Take care of yourself</span>
                <h2 className="firt-part-logo">HOLY</h2>

                <div className="main-text">
                    <h2 className="headerr">Допомога при використанні</h2>

                    <p className="textt">Елітна приватна лікарня в Києві - сучасний заклад у престижному районі з
                        високотехнологічним обладнанням. Індивідуальні палати, комфорт та конфіденційність.
                        Кваліфікований медперсонал, широкий спектр послуг, включаючи косметологію та антивікову
                        медицину. Підвищений рівень обслуговування та уваги до пацієнтів </p>
                </div>
            </div>

            <div className="col-4 col-12-lg sec-part-logo-main">
                <h2 className="sec-part-logo">LOCKET</h2>
                <span className="subscript_sec">and try not to die, please. </span>
            </div>
        </div>
    );
}

export default Landing;

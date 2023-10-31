import { Routes, Route } from 'react-router-dom';
import Registration from './pages/registration/Registration';
import Appointment from "./pages/appointment/appointment";
import Doctor from "./pages/doctors/doctors";
import Landing from "./pages/landing/landing";
import NavBar from "./component/NavBar";


const App = () => {
  return (
      <div className="App">
        <nav>
            <NavBar />
        </nav>
        <main>
            <Routes>
                <Route path="/registration" element={<Registration />} />
                <Route path="/appointment" element={<Appointment />} />
                <Route path="/doctors" element={<Doctor />} />
                <Route path="/" element={<Landing />} />
                <Route path="/landing" element={<Landing />} />
            </Routes>
        </main>
      </div>
  );
}

export default App;

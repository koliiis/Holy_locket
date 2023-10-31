import { Routes, Route } from 'react-router-dom';
import Registration from './pages/Registration';
import './App.css';
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
            </Routes>
        </main>
      </div>
  );
}

export default App;

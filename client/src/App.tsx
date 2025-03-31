import { Outlet } from 'react-router';
import { Navbar } from './components';

const App = () => {
  return (
    <div className="mx-5 md:mx-[6%]">
      <Navbar />
      <Outlet />
    </div>
  );
};

export default App;

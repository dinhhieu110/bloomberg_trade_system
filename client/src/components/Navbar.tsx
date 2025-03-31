import { Link } from 'react-router-dom';
// import { useAuth } from "../../Context/useAuth";

interface Props {}

const Navbar = (props: Props) => {
  //   const { isLoggedIn, user, logout } = useAuth();
  const isLoggedIn = () => false;
  const user = {
    userName: 'Wilson',
  };
  const logout = () => {
    console.log('Logged out...');
  };

  return (
    <nav className="p-6">
      <div className="flex items-center justify-between">
        <div className="flex items-center space-x-20">
          <Link to="/">
            <h1 className="text-primary text-3xl font-bold">Wilson</h1>
          </Link>
          <div className="hidden font-bold lg:flex items-center justify-between gap-2">
            <Link to="/search" className="pt-2 text-black hover:border-b-2">
              Explore
            </Link>
            <Link to="/dashboard" className="pt-2 text-black hover:border-b-2">
              Dashboard
            </Link>
          </div>
        </div>
        {isLoggedIn() ? (
          <div className="hidden lg:flex items-center space-x-6 text-back">
            <div className="hover:text-darkBlue">Welcome, {user?.userName}</div>
            <a
              onClick={logout}
              className="px-8 py-3 font-bold rounded text-white bg-primary hover:opacity-70"
            >
              Logout
            </a>
          </div>
        ) : (
          <div className="hidden lg:flex items-center space-x-6 text-back">
            <Link to="/login" className="hover:text-darkBlue">
              Login
            </Link>
            <Link
              to="/register"
              className="px-8 py-3 font-bold rounded text-white bg-primary hover:opacity-70"
            >
              Signup
            </Link>
          </div>
        )}
      </div>
    </nav>
  );
};

export default Navbar;

import { createBrowserRouter } from 'react-router';
import App from '../App';
import { CompanyPage, DesignGuide, Homepage, SearchPage } from '../pages';
import { CompanyProfile, IncomeStatement } from '../components';

export const router = createBrowserRouter([
  {
    path: '/',
    element: <App />,
    children: [
      {
        path: '',
        element: <Homepage />,
      },
      {
        path: 'search',
        element: <SearchPage />,
      },
      {
        path: 'design-guide',
        element: <DesignGuide />,
      },
      {
        path: 'company/:ticker',
        element: <CompanyPage />,
        children: [
          {
            path: 'company-profile',
            element: <CompanyProfile />,
          },
          {
            path: 'income-statement',
            element: <IncomeStatement />,
          },
        ],
      },
    ],
  },
]);

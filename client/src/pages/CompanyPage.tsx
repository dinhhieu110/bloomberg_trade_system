import { FC, useEffect, useState } from 'react';
import { useParams } from 'react-router';
import { getCompanyDetails } from '../endpoints';
import { CompanyProfile } from '../interfaces/company';
interface ICompanyPageProps {}

const CompanyPage: FC<ICompanyPageProps> = (props) => {
  const { ticker } = useParams();
  const [company, setCompany] = useState<CompanyProfile>();
  const [serverError, setSeverError] = useState<string>('');

  useEffect(() => {
    const getCompany = async () => {
      const result = await getCompanyDetails(ticker!);
      if (typeof result === 'string') {
        setSeverError(result);
      } else if (Array.isArray(result?.data)) {
        setCompany(result?.data[0]);
      }
    };
    getCompany();
  }, []);
  return (
    <>
      {company ? (
        <div>{company.companyName}</div>
      ) : (
        <div>Company not found!</div>
      )}
    </>
  );
};

export default CompanyPage;

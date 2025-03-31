import { FC, useEffect, useState } from "react";
import { useParams } from "react-router";
import { getCompanyDetails } from "../endpoints";
import { CompanyProfile } from "../interfaces/company";
import { CompanyDashboard, Sidebar, Tile } from "../components";
interface ICompanyPageProps {}

const CompanyPage: FC<ICompanyPageProps> = (props) => {
  const { ticker } = useParams();
  const [company, setCompany] = useState<CompanyProfile>();
  const [serverError, setSeverError] = useState<string>("");

  useEffect(() => {
    const getCompany = async () => {
      const result = await getCompanyDetails(ticker!);
      if (typeof result === "string") {
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
        <div className="w-full relative flex ct-docs-disable-sidebar-content overflow-x-hidden">
          <Sidebar />
          <CompanyDashboard ticker={ticker!}>
            <Tile title="Company Name" subTitle={company.companyName} />
            <Tile title="Price" subTitle={"$" + company.price.toString()} />
            <Tile title="DCF" subTitle={"$" + company.dcf.toString()} />
            <Tile title="Sector" subTitle={company.sector} />
            {/* <CompFinder ticker={company.symbol} />
            <TenKFinder ticker={company.symbol} /> */}
            <p className="bg-white shadow rounded text-medium font-medium text-gray-900 p-3 mt-1 m-4">
              {company.description}
            </p>
          </CompanyDashboard>
        </div>
      ) : (
        <div>Company not found!</div>
      )}
    </>
  );
};

export default CompanyPage;

import { useEffect, useState } from "react";
import { CompanyKeyMetrics } from "../interfaces/company";
import RatioList from "./RatioList";
import { getKeyMetrics } from "../endpoints";
import { useOutletContext } from "react-router";
import { formatLargeNonMonetaryNumber, formatRatio } from "../utils";

type Props = {};

const columns = [
  {
    label: "Market Cap",
    render: (company: CompanyKeyMetrics) =>
      formatLargeNonMonetaryNumber(company.marketCap),
    subTitle: "Total value of a company's share of stock",
  },
  {
    label: "Current Ratio",
    render: (company: CompanyKeyMetrics) => formatRatio(company.currentRatio),
    subTitle: "Total value of a company's share of stock",
  },
  {
    label: "Return On Equity",
    render: (company: CompanyKeyMetrics) => formatRatio(company.roe),
    subTitle: "Total value of a company's share of stock",
  },
  {
    label: "Cash Per Share",
    render: (company: CompanyKeyMetrics) => formatRatio(company.cashPerShare),
    subTitle: "Total value of a company's share of stock",
  },
  {
    label: "Current Ratio",
    render: (company: CompanyKeyMetrics) => formatRatio(company.currentRatio),
    subTitle: "Total value of a company's share of stock",
  },
  {
    label: "Return On Equity",
    render: (company: CompanyKeyMetrics) => formatRatio(company.roe),
    subTitle: "Total value of a company's share of stock",
  },
];

const CompanyProfile = (props: Props) => {
  const ticker = useOutletContext<string>();
  const [companyData, setCompanyData] = useState<CompanyKeyMetrics>();
  useEffect(() => {
    const getCompanyKeyRatios = async () => {
      const value = await getKeyMetrics(ticker);
      // Get the latest year data
      setCompanyData(value?.data[0]);
    };
    getCompanyKeyRatios();
  }, []);
  return (
    <>
      {companyData ? (
        <>
          <RatioList columns={columns} data={companyData} />
        </>
      ) : (
        <h1>No data found</h1>
      )}
    </>
  );
};

export default CompanyProfile;

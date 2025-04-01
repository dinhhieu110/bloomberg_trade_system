import React, { useEffect, useState } from "react";
import { CompanyBalanceSheet, CompanyCashFlow } from "../interfaces/company";
import { useOutletContext } from "react-router";
import { getBalanceSheet } from "../endpoints";
import RatioList from "./RatioList";

type Props = {};
const columns = [
  {
    label: "Date",
    render: (company: CompanyCashFlow) => company.date,
  },
  {
    label: "Operating Cashflow",
    render: (company: CompanyCashFlow) => company.totalInvestments,
  },
  {
    label: "Investing Cashflow",
    render: (company: CompanyCashFlow) => company.totalInvestments,
  },
  {
    label: "Financing Cashflow",
    render: (company: CompanyCashFlow) => company.totalInvestments,
  },
  {
    label: "Cash At End of Period",
    render: (company: CompanyCashFlow) => company.totalInvestments,
  },
  {
    label: "CapEX",
    render: (company: CompanyCashFlow) => company.totalInvestments,
  },
  {
    label: "Issuance Of Stock",
    render: (company: CompanyCashFlow) => company.totalInvestments,
  },
  {
    label: "Free Cash Flow",
    render: (company: CompanyCashFlow) => company.totalInvestments,
  },
];
const BalanceSheet = (props: Props) => {
  const ticker = useOutletContext<string>();
  const [balanceSheet, setBalanceSheet] = useState<CompanyBalanceSheet>();

  useEffect(() => {
    const fetchBalanceSheet = async () => {
      const result = await getBalanceSheet(ticker);
      setBalanceSheet(result?.data[0]);
    };
    fetchBalanceSheet();
  }, []);

  return (
    <>
      {balanceSheet ? (
        <RatioList data={balanceSheet} columns={columns} />
      ) : (
        <p className="mb-3 mt-3 text-sm font-semibold text-center text-gray-500">
          There's no data to display
        </p>
      )}
    </>
  );
};

export default BalanceSheet;

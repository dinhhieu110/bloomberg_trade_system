import React, { useEffect, useState } from "react";
import { CompanyCashFlow } from "../interfaces/company";
import { useOutletContext } from "react-router";
import { getCashflow } from "../endpoints";
import Table from "./Table";

type Props = {};

const columns = [
  {
    label: "Date",
    render: (company: CompanyCashFlow) => company.date,
  },
  {
    label: "Operating Cashflow",
    render: (company: CompanyCashFlow) => company.operatingCashFlow,
  },
  {
    label: "Investing Cashflow",
    render: (company: CompanyCashFlow) =>
      company.netCashUsedForInvestingActivites,
  },
  {
    label: "Financing Cashflow",
    render: (company: CompanyCashFlow) =>
      company.netCashUsedProvidedByFinancingActivities,
  },
  {
    label: "Cash At End of Period",
    render: (company: CompanyCashFlow) => company.cashAtEndOfPeriod,
  },
  {
    label: "CapEX",
    render: (company: CompanyCashFlow) => company.capitalExpenditure,
  },
  {
    label: "Issuance Of Stock",
    render: (company: CompanyCashFlow) => company.commonStockIssued,
  },
  {
    label: "Free Cash Flow",
    render: (company: CompanyCashFlow) => company.freeCashFlow,
  },
];
const CashflowStatement = (props: Props) => {
  const ticker = useOutletContext<string>();
  const [cashflowData, setCashFlowData] = useState<CompanyCashFlow[]>([]);
  console.log("cashflowData:", cashflowData);
  useEffect(() => {
    const fetCashflow = async () => {
      const result = await getCashflow(ticker);

      setCashFlowData(result!.data);
    };
    fetCashflow();
  }, []);

  return (
    <>
      {cashflowData ? (
        <Table columns={columns} data={cashflowData} />
      ) : (
        <p className="mb-3 mt-3 text-sm font-semibold text-center text-gray-500">
          There's no data to display
        </p>
      )}
    </>
  );
};

export default CashflowStatement;

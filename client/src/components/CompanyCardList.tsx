import { FC, JSX, SyntheticEvent } from "react";
import CompanyCard from "./CompanyCard";
import { CompanySearch } from "../interfaces/company";
import { v4 as uuidv4 } from "uuid";

interface ICompanyCardListProps {
  searchResults: CompanySearch[];
  onAddFavoriteStock: (e: SyntheticEvent) => void;
}

const CompanyCardList: FC<ICompanyCardListProps> = ({
  searchResults,
  onAddFavoriteStock,
}): JSX.Element => {
  const isListEmpty = searchResults.length === 0;
  return (
    <div className="mt-6">
      <h1 className="text-2xl font-semibold">Stock companies</h1>
      {isListEmpty ? (
        <p className="mb-3 mt-3 text-xl font-semibold text-center text-gray-500">
          There's no data to display
        </p>
      ) : (
        <table className="w-full shadow-xl mt-2 border-separate border-spacing-x-4 rounded-lg">
          <thead>
            <tr>
              {/* <th className="1/3">Company NAME</th>
          <th className="w-1/3">Currency</th>
          <th className="w-1/3">Exchange</th> */}
              <th className="text-start">Company NAME</th>
              <th className="text-start">Currency</th>
              <th className="text-start">Exchange</th>
              <th className="text-start"></th>
            </tr>
          </thead>
          <tbody className="gap-4">
            {searchResults.map((company) => (
              <CompanyCard
                id={company.symbol}
                company={company}
                onAddFavoriteStock={onAddFavoriteStock}
              />
            ))}
          </tbody>
        </table>
      )}
    </div>
  );
};

export default CompanyCardList;

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
  return isListEmpty ? (
    <h1 className="text-gray-500">There's no data to display</h1>
  ) : (
    <div>
      {searchResults.map((company) => (
        <CompanyCard
          id={company.symbol}
          company={company}
          onAddFavoriteStock={onAddFavoriteStock}
        />
      ))}
    </div>
  );
};

export default CompanyCardList;

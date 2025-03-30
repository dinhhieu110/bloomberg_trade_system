import { FC, JSX, SyntheticEvent } from "react";
import { CompanySearch } from "../interfaces/company";
import AddFavoriteStock from "./AddFavoriteStock";

interface ICompanyCardProps {
  id: string;
  company: CompanySearch;
  onAddFavoriteStock: (e: SyntheticEvent) => void;
}
const CompanyCard: FC<ICompanyCardProps> = ({
  company,
  id,
  onAddFavoriteStock,
}): JSX.Element => {
  const { currency, exchange, name, exchangeFullName, symbol } = company;
  return (
    <div key={id} className="rounded-xl shadow-xl text-center">
      <img
        className="rounded-full w-36 h-36 object-cover text-center"
        src="/image.jpeg"
        alt="company_logo"
      />
      <div>
        <h2>
          {name}({symbol})
        </h2>
        <p>{currency}</p>
      </div>
      <p>
        {exchangeFullName} - {exchange}
      </p>
      <AddFavoriteStock
        onAddFavoriteStock={onAddFavoriteStock}
        symbol={symbol}
      />
    </div>
  );
};

export default CompanyCard;

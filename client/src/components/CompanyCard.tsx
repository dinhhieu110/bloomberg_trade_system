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
    <tr>
      <td className="py-4 text-st">{name}</td>
      <td className="py-4">{currency}</td>
      <td className="py-4">
        {symbol}-{exchange}
      </td>
      <td className="py-4">
        <AddFavoriteStock
          onAddFavoriteStock={onAddFavoriteStock}
          symbol={symbol}
        />
      </td>
    </tr>
  );
};

export default CompanyCard;

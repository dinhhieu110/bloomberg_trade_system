import { FC, JSX } from "react";
import Card from "./Card";
import { CompanySearch } from "../interfaces/company";
import { v4 as uuidv4 } from "uuid";

interface ICardListProps {
  searchResults: CompanySearch[];
}

const CardList: FC<ICardListProps> = ({ searchResults }): JSX.Element => {
  const isListEmpty = searchResults.length === 0;
  return isListEmpty ? (
    <h1 className="text-gray-500">There's no data to display</h1>
  ) : (
    <div>
      {searchResults.map((company) => (
        <Card id={uuidv4()} company={company} />
      ))}
    </div>
  );
};

export default CardList;

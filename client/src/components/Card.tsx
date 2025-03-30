import { FC, JSX } from "react";
import { CompanySearch } from "../interfaces/company";

interface ICardProps {
  id: string;
  company: CompanySearch;
}
const Card: FC<ICardProps> = ({ company, id }): JSX.Element => {
  const { currency, exchangeShortName, name, stockExchange, symbol } = company;
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
        {exchangeShortName} - {stockExchange}
      </p>
    </div>
  );
};

export default Card;

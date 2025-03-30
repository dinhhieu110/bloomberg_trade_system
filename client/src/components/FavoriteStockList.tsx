import { FC } from "react";
import FavoriteStockCard from "./FavoriteStockCard";

interface IFavoriteStockListProps {
  favoriteStocks: string[];
}

const FavoriteStockList: FC<IFavoriteStockListProps> = (props) => {
  const { favoriteStocks } = props;
  const isListEmpty = favoriteStocks.length === 0;
  return (
    <div>
      <h2>My favorite stocks</h2>
      {isListEmpty ? (
        <p>There's no data to display.</p>
      ) : (
        <ul>
          {favoriteStocks.map((stock) => (
            <FavoriteStockCard stock={stock} />
          ))}
        </ul>
      )}
    </div>
  );
};

export default FavoriteStockList;

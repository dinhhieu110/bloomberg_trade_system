import { FC, SyntheticEvent } from "react";
import FavoriteStockCard from "./FavoriteStockCard";
import { v4 as uuidv4 } from "uuid";

interface IFavoriteStockListProps {
  favoriteStocks: string[];
  onRemoveFavoriteStock: (e: SyntheticEvent) => void;
}

const FavoriteStockList: FC<IFavoriteStockListProps> = (props) => {
  const { favoriteStocks, onRemoveFavoriteStock } = props;
  const isListEmpty = favoriteStocks.length === 0;
  return (
    <div>
      <h2>My favorite stocks</h2>
      {isListEmpty ? (
        <p>There's no data to display.</p>
      ) : (
        <ul>
          {favoriteStocks.map((stock) => (
            <FavoriteStockCard
              id={uuidv4()}
              stock={stock}
              onRemoveFavoriteStock={onRemoveFavoriteStock}
            />
          ))}
        </ul>
      )}
    </div>
  );
};

export default FavoriteStockList;

import { FC, SyntheticEvent } from 'react';
import FavoriteStockCard from './FavoriteStockCard';
import { v4 as uuidv4 } from 'uuid';

interface IFavoriteStockListProps {
  favoriteStocks: string[];
  onRemoveFavoriteStock: (e: SyntheticEvent) => void;
}

const FavoriteStockList: FC<IFavoriteStockListProps> = (props) => {
  const { favoriteStocks, onRemoveFavoriteStock } = props;
  const isListEmpty = favoriteStocks.length === 0;
  return (
    <div className="mt-6">
      <h1 className="text-lg font-semibold">My favorite stocks</h1>
      {isListEmpty ? (
        <p className="mb-3 mt-3 text-sm font-semibold text-center text-gray-500">
          There's no data to display
        </p>
      ) : (
        <ul className="grid md:flex flex-wrap space-x-4 w-full">
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

import { FC, SyntheticEvent } from "react";
import RemoveFavoriteStock from "./RemoveFavoriteStock";

type IFavoriteStockCardProps = {
  id: string;
  stock: string;
  onRemoveFavoriteStock: (e: SyntheticEvent) => void;
};

const FavoriteStockCard: FC<IFavoriteStockCardProps> = (props) => {
  const { stock, onRemoveFavoriteStock, id } = props;
  return (
    <div className="shadow-lg px-8 py-4 relative" key={id}>
      <h4>{stock}</h4>
      <RemoveFavoriteStock
        onRemoveFavoriteStock={onRemoveFavoriteStock}
        stock={stock}
      />
    </div>
  );
};

export default FavoriteStockCard;

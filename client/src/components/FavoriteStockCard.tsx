import { FC, SyntheticEvent } from "react";
import RemoveFavoriteStock from "./RemoveFavoriteStock";
import { Link } from "react-router";

type IFavoriteStockCardProps = {
  id: string;
  stock: string;
  onRemoveFavoriteStock: (e: SyntheticEvent) => void;
};

const FavoriteStockCard: FC<IFavoriteStockCardProps> = (props) => {
  const { stock, onRemoveFavoriteStock, id } = props;
  return (
    <div className="shadow-lg px-8 py-4 relative max-w-40" key={id}>
      <Link to={`/company/${stock}/company-profile`}>{stock}</Link>
      <RemoveFavoriteStock
        onRemoveFavoriteStock={onRemoveFavoriteStock}
        stock={stock}
      />
    </div>
  );
};

export default FavoriteStockCard;

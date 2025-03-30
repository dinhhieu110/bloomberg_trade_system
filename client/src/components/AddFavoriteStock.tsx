import { FC, SyntheticEvent } from "react";

interface IAddFavoriteStockProps {
  onAddFavoriteStock: (e: SyntheticEvent) => void;
  symbol: string;
}

const AddFavoriteStock: FC<IAddFavoriteStockProps> = (props) => {
  const { onAddFavoriteStock, symbol } = props;
  return (
    <form onSubmit={onAddFavoriteStock}>
      <input readOnly hidden value={symbol} />
      <button type="submit">Add</button>
    </form>
  );
};

export default AddFavoriteStock;

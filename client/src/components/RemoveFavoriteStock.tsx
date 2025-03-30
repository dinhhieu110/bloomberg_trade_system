import { SyntheticEvent } from "react";

interface Props {
  onRemoveFavoriteStock: (e: SyntheticEvent) => void;
  stock: string;
}

const RemoveFavoriteStock = (props: Props) => {
  const { onRemoveFavoriteStock, stock } = props;
  return (
    <div className="absolute right-0 top-0 ">
      <form onSubmit={onRemoveFavoriteStock}>
        <input hidden value={stock} />
        <button className="cursor-pointer hover:bg-transparent" type="submit">
          x
        </button>
      </form>
    </div>
  );
};

export default RemoveFavoriteStock;

import { ClipLoader } from "react-spinners";
type Props = {
  isLoading?: boolean;
};

const Spinner = ({ isLoading = true }: Props) => {
  return (
    <>
      <div className="fixed top-[50%] left-[50%]" id="loading-spinner">
        <ClipLoader
          color="#36d7b7"
          loading={isLoading}
          size={35}
          aria-label="Loading Spinner"
          data-testid="loader"
        />
      </div>
    </>
  );
};

export default Spinner;

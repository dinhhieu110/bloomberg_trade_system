import axios from "axios";
import { CompanySearch } from "./interfaces/company";

interface ISearchRes {
  data: CompanySearch[];
}

export const searchCompanies = async (query: string) => {
  try {
    const data = await axios.get<ISearchRes>(
      `https://financialmodelingprep.com/stable/search-symbol?query=${query}&apikey=${
        import.meta.env.VITE_API_KEY
      }`
    );
    return data;
  } catch (error) {
    if (axios.isAxiosError(error)) {
      console.error("Error message: ", error.message);
    } else {
      console.error("Unexpected error: ", error);
      return "An expected error has occurred.";
    }
  }
};

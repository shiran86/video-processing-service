import { useQuery } from "@tanstack/react-query";
import { getCurrentUser } from "./service";
import { authQueryKeys } from "./queryKeys";

export const useCurrentUser = () => {
    return useQuery({
        queryKey: authQueryKeys.currentUser,
        queryFn: getCurrentUser,
        staleTime: Infinity,
    });
};
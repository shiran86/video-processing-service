import { useCurrentUser } from "../useCurrentUser";
import { LogoutButton } from "./LogoutButton";

export const AuthStatus = () => {

    const { data: currentUser, isLoading, isError } = useCurrentUser();

    if (isLoading) {
        return <div>Loading...</div>;
    }

    if (isError || !currentUser) {
        return <div>Not logged in</div>;
    }

    return <div>
        <div>Logged in as {currentUser.email}</div>
        <LogoutButton />
    </div>;
}
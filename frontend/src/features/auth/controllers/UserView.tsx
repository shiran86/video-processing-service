import { useCurrentUser } from "../useCurrentUser";
import { LogoutButton } from "./LogoutButton";

export const UserView = () => {
    const { data: currentUser } = useCurrentUser();

    if (!currentUser) {
        return null;
    }

    return <div>
        <div>Logged in as {currentUser.email}</div>
        <LogoutButton />
    </div>;
}

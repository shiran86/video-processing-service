import { useCurrentUser } from "../useCurrentUser";
import { LogoutButton } from "./LogoutButton";
import styles from "../../../styles.module.scss";

export const UserView = () => {
    const { data: currentUser } = useCurrentUser();

    if (!currentUser) {
        return null;
    }

    return <div className={styles.userViewContent}>
        <div>Logged in as {currentUser.email}</div>
        <LogoutButton />
    </div>;
}

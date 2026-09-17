import './App.css'
import { AuthGuard } from './features/auth/components/AuthGuard/AuthGuard'
import { LoginView } from './features/auth/components/LoginView'
import { UserView } from './features/auth/controllers/UserView'
import { VideoPage } from './features/videos/videoPage/VideoPage'
import styles from './styles.module.scss';

function App() {
  return (
    <section className={styles.appContainer}>
      <AuthGuard fallback={<LoginView />}>
        <div className={styles.authenticatedLayout}>
          <div className={styles.userView}>
            <UserView />
          </div>
          <VideoPage />
        </div>
      </AuthGuard>
    </section>
  )
}

export default App

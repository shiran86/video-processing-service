import './App.css'
import { AuthGuard } from './features/auth/components/AuthGuard/AuthGuard'
import { LoginView } from './features/auth/components/LoginView'
import { UserView } from './features/auth/controllers/UserView'
import { VideoPage } from './features/videos/videoPage/VideoPage'
import styles from './styles.module.scss';

function App() {
  return (
    <AuthGuard fallback={<LoginView />}>
      <section className={styles.appContainer}>
        <UserView />
        <div className={styles.authenticatedLayout}>
          <VideoPage />
        </div>
      </section>
    </AuthGuard>
  )
}

export default App

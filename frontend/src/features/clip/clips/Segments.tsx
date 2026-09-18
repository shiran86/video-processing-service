import type { SegmentsProps } from './types'
import styles from './styles.module.scss'

export const Segments = ({ segments }: SegmentsProps) => {
  return (
    <section className={styles.container} aria-label="Video clips">
      <h2>Clips</h2>

      <ul className={styles.list}>
        {segments.map((segment, index) => (
          <li
            className={styles.clip}
            key={`${segment.startTime}-${segment.endTime}-${index}`}
          >
            <span>Clip {index + 1}</span>
            <span>
              {segment.startTime}s - {segment.endTime}s
            </span>
          </li>
        ))}
      </ul>
    </section>
  )
}

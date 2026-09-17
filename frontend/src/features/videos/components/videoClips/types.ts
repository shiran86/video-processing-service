export interface VideoClip {
    start: number
    end: number
}

export type VideoClipsProps = {
  clips: VideoClip[]
}
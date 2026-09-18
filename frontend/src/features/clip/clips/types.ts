import type { CreateClipSegmentRequest } from "../types"

export type ClipsProps = {
  clips: CreateClipSegmentRequest[]
  onUpload: (clips: CreateClipSegmentRequest[]) => void
}
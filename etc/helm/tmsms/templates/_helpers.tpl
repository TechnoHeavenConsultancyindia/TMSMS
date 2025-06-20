{{- define "tmsms.hosts.authserver" -}}
{{- print "https://" (.Values.global.hosts.authserver | replace "[RELEASE_NAME]" .Release.Name) -}}
{{- end -}}
{{- define "tmsms.hosts.webgateway" -}}
{{- print "https://" (.Values.global.hosts.webgateway | replace "[RELEASE_NAME]" .Release.Name) -}}
{{- end -}}
{{- define "tmsms.hosts.kibana" -}}
{{- print "https://" (.Values.global.hosts.kibana | replace "[RELEASE_NAME]" .Release.Name) -}}
{{- end -}}
{{- define "tmsms.hosts.grafana" -}}
{{- print "https://" (.Values.global.hosts.grafana | replace "[RELEASE_NAME]" .Release.Name) -}}
{{- end -}}
{{- define "tmsms.hosts.angular" -}}
{{- print "https://" (.Values.global.hosts.angular | replace "[RELEASE_NAME]" .Release.Name) -}}
{{- end -}}
